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
class PatchBigSegmentStoreIntegrationExample
{
    fun patchBigSegmentStoreIntegration()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val patchOperation1 = PatchOperation(
            op = "replace",
            path = "/exampleField",
        )

        val patchOperation = arrayListOf<PatchOperation>(
            patchOperation1,
        )

        try
        {
            val response = PersistentStoreIntegrationsBetaApi().patchBigSegmentStoreIntegration(
                projectKey = null,
                environmentKey = null,
                integrationKey = null,
                integrationId = null,
                patchOperation = patchOperation,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersistentStoreIntegrationsBetaApi#patchBigSegmentStoreIntegration")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersistentStoreIntegrationsBetaApi#patchBigSegmentStoreIntegration")
            e.printStackTrace()
        }
    }
}
