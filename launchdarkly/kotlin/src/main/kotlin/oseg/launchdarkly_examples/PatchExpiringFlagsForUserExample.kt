package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PatchExpiringFlagsForUserExample
{
    fun patchExpiringFlagsForUser()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val instructions1 = InstructionUserRequest(
            kind = InstructionUserRequest.Kind.addExpireUserTargetDate,
            flagKey = "sample-flag-key",
            variationId = "ce12d345-a1b2-4fb5-a123-ab123d4d5f5d",
            value = 16534692,
            version = 1,
        )

        val instructions = arrayListOf<InstructionUserRequest>(
            instructions1,
        )

        val patchUsersRequest = PatchUsersRequest(
            comment = "optional comment",
            instructions = instructions,
        )

        try
        {
            val response = UserSettingsApi().patchExpiringFlagsForUser(
                projectKey = "the-project-key",
                userKey = "the-user-key",
                environmentKey = "the-environment-key",
                patchUsersRequest = patchUsersRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling UserSettingsApi#patchExpiringFlagsForUser")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling UserSettingsApi#patchExpiringFlagsForUser")
            e.printStackTrace()
        }
    }
}
