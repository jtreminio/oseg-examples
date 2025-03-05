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
class PatchCustomRoleExample
{
    fun patchCustomRole()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val patch1 = PatchOperation(
            op = "add",
            path = "/policy/0",
        )

        val patch = arrayListOf<PatchOperation>(
            patch1,
        )

        val patchWithComment = PatchWithComment(
            patch = patch,
        )

        try
        {
            val response = CustomRolesApi().patchCustomRole(
                customRoleKey = null,
                patchWithComment = patchWithComment,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling CustomRolesApi#patchCustomRole")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling CustomRolesApi#patchCustomRole")
            e.printStackTrace()
        }
    }
}
