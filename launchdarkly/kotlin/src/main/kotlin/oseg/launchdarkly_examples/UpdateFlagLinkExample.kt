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
class UpdateFlagLinkExample
{
    fun updateFlagLink()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val patchOperation1 = PatchOperation(
            op = "replace",
            path = "/title",
        )

        val patchOperation = arrayListOf<PatchOperation>(
            patchOperation1,
        )

        try
        {
            val response = FlagLinksBetaApi().updateFlagLink(
                projectKey = null,
                featureFlagKey = null,
                id = null,
                patchOperation = patchOperation,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling FlagLinksBetaApi#updateFlagLink")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling FlagLinksBetaApi#updateFlagLink")
            e.printStackTrace()
        }
    }
}
